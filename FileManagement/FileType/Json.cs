using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement.FileType
{
    public class Json : CustomFile
    {
        #region Properties
        #endregion

        #region Constructor
        public Json(string path)
            : base(path)
        {

        }
        #endregion

        #region Functions
        //public static string WriteFromObject()
        //{
        //    // Create User object.
        //    var user = new User("Bob", 42);

        //    // Create a stream to serialize the object to.
        //    var ms = new MemoryStream();

        //    // Serializer the User object to the stream.
        //    var ser = new DataContractJsonSerializer(typeof(User));
        //    ser.WriteObject(ms, user);
        //    byte[] json = ms.ToArray();
        //    ms.Close();
        //    return Encoding.UTF8.GetString(json, 0, json.Length);
        //}

        //// Deserialize a JSON stream to a User object.
        //public static User ReadToObject(string json)
        //{
        //    var deserializedUser = new User();
        //    var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
        //    var ser = new DataContractJsonSerializer(deserializedUser.GetType());
        //    deserializedUser = ser.ReadObject(ms) as User;
        //    ms.Close();
        //    return deserializedUser;BinaryFormatter 
        //}
        #endregion
    }
}
