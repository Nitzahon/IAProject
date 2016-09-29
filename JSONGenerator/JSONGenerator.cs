using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace JSON
{
	public class JSONFieldAttribute : Attribute
	{
	}

	public enum OnlyMarkedFields
	{
		No,
		Yes
	}

	public enum Compressed
	{
		No,
		Yes
	}

	public interface IJSONHasSelectedFields
	{
		bool IsFieldSelectedForJSon( FieldInfo fi );
	}

	/// <summary>
	/// Obtains the JSONGenerator string for a class 
	/// </summary>
	public class JSONGenerator
	{
		public const Compressed DefaultCompressedValue = Compressed.Yes;

		private JSONGenerator()
		{
		}

		public static string GetJSONRepresentation( object obj )
		{
			return GetJSONRepresentation( obj, OnlyMarkedFields.No, DefaultCompressedValue );
		}

		public static string GetJSONRepresentation( object obj, Compressed c )
		{
			return GetJSONRepresentation( obj, OnlyMarkedFields.No, c );
		}

		public static string GetJSONRepresentation( object obj, OnlyMarkedFields WhichFields, Compressed c )
		{
			StringBuilder sb = new StringBuilder();
			GetJSONRepresentation( string.Empty, obj, null, sb, c == Compressed.Yes ? -100 : 0, AddComma.No, WhichFields );
			return c == Compressed.Yes ? sb.ToString().Replace( NewLine, "" ) : sb.ToString();
		}

		protected static string[] TabStrings = 
		{
			"",
			"\t",
			"\t\t",
			"\t\t\t",
			"\t\t\t\t",
			"\t\t\t\t\t",
			"\t\t\t\t\t\t",
			"\t\t\t\t\t\t\t",
			"\t\t\t\t\t\t\t\t",
		};

		public static readonly string NewLine = "\r\n";

		/// <summary>
		/// or the quote mark 
		/// </summary>
		protected static readonly string StringMarker = "'";

		protected static string GetStringOfTabs( int TabCount )
		{
			if( TabCount < 0 )
				return "";

			if( TabCount < TabStrings.Length )
				return TabStrings[ TabCount ];
			else
				return TabStrings[ TabStrings.Length - 1 ] + GetStringOfTabs( TabCount - ( TabStrings.Length - 1 ) );
		}

		protected static string FormatNumber( string s )
		{
			return s.Replace( System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, "." ); // Javascript only uses . 
		}

		protected static string FormatString( string s )
		{
			return s.Replace( @"\", @"\\" ).Replace( @"'", @"\'" )/*.Replace( "\"", "\\\"" )*/.Replace( NewLine, @"\r\n" );
		}

		protected static string FormatName( string Name )
		{
			if( Name.StartsWith( "<" ) && Name.EndsWith( ">i__Field" ) ) // automatic types in .net 3.5 
				return Name.Substring( 1, Name.Length - "<".Length - ">i__Field".Length );
			return Name;
		}

		protected static string FormatDate( object d )
		{
			DateTime date = ( DateTime ) d;
			return string.Format( "new Date( {0}, {1}, {2}, {3}, {4}, {5} )", date.Year, date.Month - 1, date.Day, date.Hour, date.Minute, date.Second );
		}

		protected static void AddSimpleField( FieldInfo fi, object obj, StringBuilder sb, int TabCount, AddComma AddComma_ )
		{
			object FieldValue = fi != null ? fi.GetValue( obj ) : obj;
			Type type = fi != null ? fi.FieldType : obj.GetType();

			string value = null != FieldValue ? FieldValue.ToString() : "null";
			if( type == typeof( bool ) )
				value = value.ToLower();
			else
				if( type == typeof( string ) )
					value = FormatString( value );
				else
					if( type == typeof( DateTime ) )
						value = FormatDate( FieldValue );
					else
						value = FormatNumber( value );
			string around = type == typeof( string ) && null != FieldValue ? StringMarker : "";
			if( fi != null )
				sb.AppendFormat( "{0}{4}\"{1}\" : {2}{3}{2}{5}", GetStringOfTabs( TabCount ), FormatName( fi.Name ), around, value, AddComma_ == AddComma.Yes ? ", " : "", NewLine );
			else
				sb.AppendFormat( "{0}{4}{2}{3}{2}{5}", GetStringOfTabs( TabCount ), null, around, value, AddComma_ == AddComma.Yes ? ", " : "", NewLine );
		}

		protected static void BeginStructure( string Name, StringBuilder sb, ref int TabCount, AddComma AddComma_ )
		{
			Name = FormatName( Name );
			if( string.Empty != Name )
				sb.AppendFormat( "{0}{3}\"{1}\" :{2}{0}{{{2}", GetStringOfTabs( TabCount++ ), Name, NewLine, AddComma_ == AddComma.Yes ? ", " : "" );
			else
				sb.AppendFormat( "{0}{3}{{{2}", GetStringOfTabs( TabCount++ ), Name, NewLine, AddComma_ == AddComma.Yes ? ", " : "" );
		}

		protected enum AddComma
		{
			No,
			Yes
		}

		protected static void EndStructure( StringBuilder sb, ref int TabCount )
		{
			sb.AppendFormat( "{0}}}{1}", GetStringOfTabs( --TabCount ), NewLine );
		}

		protected static void BeginArray( string Name, StringBuilder sb, ref int TabCount, AddComma AddComma_ )
		{
			string tabs = GetStringOfTabs( TabCount++ );
			if( Name != string.Empty )
				sb.AppendFormat( "{0}{3}\"{1}\" :{2}{0}[{2}", tabs, FormatName( Name ), NewLine, AddComma_ == AddComma.Yes ? ", " : "" );
			else
				sb.AppendFormat( "{0}{2}[{1}", tabs, NewLine, AddComma_ == AddComma.Yes ? ", " : "" );
		}

		protected static void EndArray( StringBuilder sb, ref int TabCount )
		{
			sb.AppendFormat( "{0}]{1}", GetStringOfTabs( --TabCount ), NewLine );
		}

		protected static bool IsPrimitiveType( Type type )
		{
			return type.IsPrimitive || type == typeof( string ) || type == typeof( decimal ) || type == typeof( DateTime );
		}

		/// <summary>
		/// Returns true if anything is added to the JSON string 
		/// </summary>
		/// <param name="Name"></param>
		/// <param name="obj"></param>
		/// <param name="ObjectsAlreadyProcessed"></param>
		/// <param name="sb"></param>
		/// <param name="TabCount"></param>
		/// <param name="AddComma_"></param>
		/// <param name="WhichFields"></param>
		/// <returns></returns>
		protected static bool GetJSONRepresentation( string Name, object obj, List<object> ObjectsAlreadyProcessed, StringBuilder sb, int TabCount, AddComma AddComma_, OnlyMarkedFields WhichFields )
		{
			if( ObjectsAlreadyProcessed == null )
				ObjectsAlreadyProcessed = new List<object>();
			if( obj != null && !IsPrimitiveType( obj.GetType() ) && ObjectsAlreadyProcessed.Contains( obj ) )
				return false; // infinite recursion 
			ObjectsAlreadyProcessed.Add( obj );

			Name = FormatName( Name );
			if( null == obj )
			{
				if( Name != string.Empty )
					sb.AppendFormat( "{0}{2}{1} : null{3}", GetStringOfTabs( TabCount ), Name, AddComma_ == AddComma.Yes ? ", " : "", NewLine );
				else
					sb.AppendFormat( "{0}{1}null{2}", GetStringOfTabs( TabCount ), AddComma_ == AddComma.Yes ? ", " : "", NewLine );
				return true;
			}

			if( IsPrimitiveType( obj.GetType() ) )
			{
				AddSimpleField( null, obj, sb, TabCount, AddComma_ );
				return true;
			}

			if( obj.GetType().IsArray )
			{
				BeginArray( string.Empty, sb, ref TabCount, AddComma_ );
				bool WasAnyChildBefore = false;
				Array aobj = obj as Array;
				for( int index = 0; index < aobj.Length; ++ index )
				{
					object childobj = aobj.GetValue( index );
					WasAnyChildBefore = WasAnyChildBefore | GetJSONRepresentation( string.Empty, childobj, ObjectsAlreadyProcessed, sb, TabCount, WasAnyChildBefore ? AddComma.Yes : AddComma.No, WhichFields );
				}
				EndArray( sb, ref TabCount );

				ObjectsAlreadyProcessed.Remove( obj );
				return true;
			}
			else
			{

				IJSONHasSelectedFields objHasSelectedFields = obj as IJSONHasSelectedFields;

				BeginStructure( Name, sb, ref TabCount, AddComma_ );

				FieldInfo[] fis = obj.GetType().GetFields( BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance );

				//int NumberOfFields = 0;
				//foreach( FieldInfo fi in fis )
				//    if( WhichFields == OnlyMarkedFields.No || fi.GetCustomAttributes( typeof( JSONFieldAttribute ), false ).Length > 0 )
				//        ++NumberOfFields;

				int IndexField = -1;
				bool WasAnyFieldBefore = false;
				foreach( FieldInfo fi in fis )
				{
					object[] Attributes = fi.GetCustomAttributes( typeof( JSONFieldAttribute ), false );
					if( WhichFields == OnlyMarkedFields.No || ( Attributes.Length > 0 && Attributes[ 0 ] is JSONFieldAttribute ) )
					{
						++IndexField;

						if( objHasSelectedFields != null && !objHasSelectedFields.IsFieldSelectedForJSon( fi ) )
							continue;

						if( fi.FieldType.IsArray )
						{
							// array 

							BeginArray( fi.Name, sb, ref TabCount, WasAnyFieldBefore ? AddComma.Yes : AddComma.No );
							Array array = fi.GetValue( obj ) as Array;
							bool WasAnyChildBefore = false;
							for( int index = 0; index < array.Length; ++ index )
							{
								object childobj = array.GetValue( index );
								WasAnyChildBefore = WasAnyChildBefore | GetJSONRepresentation( string.Empty, childobj, ObjectsAlreadyProcessed, sb, TabCount, WasAnyChildBefore ? AddComma.Yes : AddComma.No, WhichFields );
							}
							EndArray( sb, ref TabCount );
						}
						else
						{
							// not an array 

							if( IsPrimitiveType( fi.FieldType ) )
								AddSimpleField( fi, obj, sb, TabCount, WasAnyFieldBefore ? AddComma.Yes : AddComma.No );
							else
								GetJSONRepresentation( fi.Name, fi.GetValue( obj ), ObjectsAlreadyProcessed, sb, TabCount, WasAnyFieldBefore ? AddComma.Yes : AddComma.No, WhichFields );
						}

						WasAnyFieldBefore = true;
					}
				}

				EndStructure( sb, ref TabCount );

				ObjectsAlreadyProcessed.Remove( obj );

				return WasAnyFieldBefore;
			}
		}
	}

}
