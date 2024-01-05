using CoreUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myapp_tests
{

    public class MockDBTransaction : IDbTransaction
    {
        public IsolationLevel IsolationLevel { get; }

        public IDbConnection? Connection { get; }


        public void Commit()
        {
        }

        public void Dispose()
        {

        }

        public void Rollback()
        {

        }
    }

    public class MockDBConnection : IDbConnection
    {
        public string ConnectionString { get; set; }

        public string Database { get; }

        public string DataSource { get; }
        public string ServerVersion { get; }

        public ConnectionState State { get; }

        public int ConnectionTimeout { get; set; }

        public IDbTransaction BeginTransaction()
        {
            return new MockDBTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return new MockDBTransaction();

        }

        public void ChangeDatabase(string databaseName)
        {

        }

        public void Close()
        {

        }

        public IDbCommand CreateCommand()
        {
            return new MockDBCommand();
        }

        public void Dispose()
        {

        }

        public void Open()
        {

        }

    }

    public class MockDbReader : IDataReader
    {
        private readonly object[][] data;
        private int currentRow = -1;
        private bool isClosed = false;

        public MockDbReader(object[][] data)
        {
            this.data = data;
        }

        public object this[string name] => GetValue(GetOrdinal(name));

        public object this[int i] => GetValue(i);

        public int Depth => 0;

        public bool IsClosed => isClosed;

        public int RecordsAffected => -1;

        public int FieldCount => data.Length;

        public void Close()
        {
            isClosed = true;
        }

        public void Dispose()
        {
            Close();
        }

        public bool Read()
        {
            if (currentRow < data[0].Length - 1)
            {
                currentRow++;
                return true;
            }
            return false;
        }

        public bool NextResult()
        {
            return false;
        }

        public bool GetBoolean(int i)
        {
            return Convert.ToBoolean(data[i][currentRow]);
        }

        public byte GetByte(int i)
        {
            return Convert.ToByte(data[i][currentRow]);
        }

        // Implement other GetXxx methods for different data types...

        public object GetValue(int i)
        {
            return data[i][currentRow];
        }

        public int GetOrdinal(string name)
        {
            for (int i = 0; i < data.Length; i++)
            {
                // Assuming the first row contains column names
                if (data[i][0].ToString() == name)
                {
                    return i;
                }
            }
            throw new IndexOutOfRangeException($"Column {name} not found.");
        }


        public bool HasRows { get; }


        public long GetBytes(int ordinal, long dataOffset, byte[]? buffer, int bufferOffset, int length)
        {
            return 0;

        }

        public char GetChar(int ordinal)
        {
            return ' ';
        }

        public long GetChars(int ordinal, long dataOffset, char[]? buffer, int bufferOffset, int length)
        {
            return 0;
        }

        public IDataReader GetData(int i)
        {
            return null;
        }

        public string GetDataTypeName(int ordinal)
        {
            return "";
        }

        public DateTime GetDateTime(int ordinal)
        {
            return DateTime.MinValue;
        }

        public decimal GetDecimal(int ordinal)
        {
            return 0;
        }

        public double GetDouble(int ordinal)
        {
            return 0;
        }


        [return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties)]
        public Type GetFieldType(int ordinal)
        {
            return typeof(string);

        }

        public float GetFloat(int ordinal)
        {
            return 0;
        }

        public Guid GetGuid(int ordinal)
        {
            return Guid.Empty;
        }

        public short GetInt16(int ordinal)
        {
            return (short)0;
        }

        public int GetInt32(int ordinal)
        {
            return 0;
        }

        public long GetInt64(int ordinal)
        {
            return 0;
        }

        public string GetName(int ordinal)
        {
            return "";

        }


        public DataTable? GetSchemaTable()
        {
            return new DataTable();
        }

        public string GetString(int ordinal)
        {
            return "";
        }


        public int GetValues(object[] values)
        {
            return 0;
        }

        public bool IsDBNull(int ordinal)
        {
            return false;
        }


    }

    public class MockDbParameter : IDbDataParameter
    {

        public DbType DbType { get; set; }
        public ParameterDirection Direction { get; set; }
        public bool IsNullable { get; set; }

        public string ParameterName { get; set; } = "";

        public int Size { get; set; } = 0;

        public string SourceColumn { get; set; } = "";

        public bool SourceColumnNullMapping { get; set; }

        public object? Value { get; set; } = new object();
        public byte Precision { get; set; } = 0;
        public byte Scale { get; set; } = 0;
        public DataRowVersion SourceVersion { get; set; }

        public void ResetDbType()
        {

        }
    }

    public class MockDBCommand : IDbCommand
    {
        public string CommandText { get; set; }
        public int CommandTimeout { get; set; }
        public CommandType CommandType { get; set; }
        public IDbConnection? Connection { get; set; }

        public IDataParameterCollection Parameters { get; }

        public IDbTransaction? Transaction { get; set; }
        public UpdateRowSource UpdatedRowSource { get; set; }

        public void Cancel()
        {

        }

        public IDbDataParameter CreateParameter()
        {
            return new MockDbParameter();
        }

        public void Dispose()
        {

        }

        public int ExecuteNonQuery()
        {
            return 1;
        }

        public IDataReader ExecuteReader()
        {
            object[][] data = new object[][]{
                new object[] { "ID", "Name", "Age" },
                new object[] { 1, "Alice", 30 },
                new object[] { 2, "Bob", 25 },
                new object[] { 3, "Charlie", 35 }
            };

            return new MockDbReader(data);
        }

        public IDataReader ExecuteReader(CommandBehavior behavior)
        {
            object[][] data = new object[][]{
                new object[] { "ID", "Name", "Age" },
                new object[] { 1, "Alice", 30 },
                new object[] { 2, "Bob", 25 },
                new object[] { 3, "Charlie", 35 }
            };
            return new MockDbReader(data);
        }

        public object? ExecuteScalar()
        {
            return 0;
        }

        public void Prepare()
        {

        }
    }

    public class MockDB : IDatabase
    {
        public List<object> Data = new List<object>();

        public MockDB() { }

        public string _ConnectionString { get; set; }

        public int ExecuteNonQuery(string sql, List<IDbDataParameter> parameters = null, CommandType commandType = CommandType.Text)
        {
            return 1;
        }

        public IDbCommand GetCommand(IDbConnection connection, string sql, CommandType cType = CommandType.Text)
        {
            return new MockDBCommand();
        }

        public IDbConnection GetConnection(bool autoopen = true)
        {
            return new MockDBConnection();
        }

        public IDataReader GetDataReader(string sql, List<IDbDataParameter> parameters = null, CommandType commandType = CommandType.Text)
        {
            object[][] data = new object[][]{
                new object[] { "ID", "Name", "Age" },
                new object[] { 1, "Alice", 30 },
                new object[] { 2, "Bob", 25 },
                new object[] { 3, "Charlie", 35 }
            };
            return new MockDbReader(data);

        }

        public DataSet GetDataSet(string sql, List<IDbDataParameter> parameters = null, CommandType commandType = CommandType.Text)
        {
            return new DataSet();

        }

        public DataTable GetDataTable(string sql, List<IDbDataParameter> parameters = null, CommandType commandType = CommandType.Text)
        {
            return new DataTable();
        }

        public IDbDataParameter GetParameter(string name, object value)
        {
            return new MockDbParameter();
        }

        public IDbDataParameter GetParameterOut(string name, object value, DbType type, int maxLength = -1, ParameterDirection direction = ParameterDirection.InputOutput)
        {
            return new MockDbParameter();
        }

        public object GetScalar(string sql, List<IDbDataParameter> parameters = null, CommandType commandType = CommandType.Text)
        {
            return 1;
        }

        // rv = Dapper.SqlMapper.Query<T>(conn, "GetAuthUserByUserName", dapperParams, null, true, null, CommandType.StoredProcedure).FirstOrDefault();
        public IEnumerable<T> Query<T>(string sql, List<IDbDataParameter> parameters = null, CommandType commandType = CommandType.Text)
        {
            return this.Data.OfType<T>();
        }
    }
}
