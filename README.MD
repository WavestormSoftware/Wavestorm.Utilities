# Wavestorm.Utilities
The Wavestorm.Utilities library is designed to support game development in both [Wavestorm Engine](https://wavestormgames.net/engine) (3D) and [Wavestorm Studio](https://wavestormgames.net/) (2D). While these engines are currently under active development and have not been officially released, the library is crafted to streamline game creation processes within the Wavestorm Engine & Wavestorm Studio environments. It offers a versatile set of utilities tailored for C# development.

Although the primary focus is on integration with Wavestorm Engine & Wavestorm Studio, the Wavestorm.Utilities library is not exclusive to these platforms and can be utilized in other C# projects as well.

---
### Methods:

#### *Wavestorm*
##### Engine
- **`GetVersion():Version`** - Retrieves the version of the Wavestorm Engine.
- **`Download(string directory):bool`** - Downloads the Wavestorm Engine to the specified directory. Returns true if successful, false otherwise.
- **`Compile(string enginePath, string projectPath, Version version, string output):bool`** - Compiles a Wavestorm project using the specified engine path, project path, version, and output directory. Returns true if compilation is successful, false otherwise.
- **`FetchAccount(string username, string apiKey):string`** - Fetches account information for the specified username and API key. Returns account details as a string.
- **`Upload(string username, string apiKey, string projectPath, Version version):bool`** - Uploads a Wavestorm project to the server using the provided username, API key, project path, and version. Returns true if the upload is successful, false otherwise.
##### *Studio*
- **`GetVersion():Version`** - Retrieves the version of the Wavestorm Studio. 
 
Please note that both the Engine and Studio methods are currently under development and and these functions are made for internal use only. They are subject to change and may not be available in the final release.

---
#### *General*
- **`GetUUID():string`** - Generates a unique identifier (UUID).
- **`GetRandomInt(int min, int max):int`** - Generates a random integer within the specified range.
- **`GetRandomString(int length, bool useNumbers, bool useSpecialCharacters):string`** - Generates a random string of the specified length, with options to include numbers and special characters.
- **`StringToByteArray(string str):byte[]`** - Converts a string to a byte array.
- **`ByteArrayToString(byte[] bytes):string`** - Converts a byte array to a string.
- **`IsNullOrEmpty<T>(T input):bool`** - Checks if the input object is null or empty.
- **`Inlist<T>(T item, params T[] list):bool`** - Checks if an item is present in a list.
- **`IsValidEmail(string email):bool`** - Validates if a given string is a valid email address.
- **`IsValidUrl(string url):bool`** - Validates if a given string is a valid URL.
- **`EncodeBase64(string plainText):string`** - Encodes a plain text string to Base64.
- **`DecodeBase64(string base64EncodedData):string`** - Decodes a Base64 encoded string.
- **`EncryptString(string plainText, string key):string`** - Encrypts a string using a symmetric key.
- **`DecryptString(string cipherText, string key):string`** - Decrypts a string using a symmetric key.
- **`EncryptStringRSA(string plainText, string publicKey):string`** - Encrypts a string using RSA with a public key.
- **`DecryptStringRSA(string cipherText, string privateKey):string`** - Decrypts a string using RSA with a private key.
- **`CompressString(string text):string`** - Compresses a string.
- **`DecompressString(string compressedText):string`** - Decompresses a compressed string.
- **`SerializeObject(object obj):string`** - Serializes an object to a JSON string.
- **`DeserializeObject(string json):object`** - Deserializes a JSON string to an object.
- **`GetPropertyValue(object obj, string propertyName):object`** - Gets the value of a property in an object.
- **`SetPropertyValue(object obj, string propertyName, object value):bool`** - Sets the value of a property in an object.
- **`GetFieldValue(object obj, string fieldName):object`** - Gets the value of a field in an object.
- **`SetFieldValue(object obj, string fieldName, object value):bool`** - Sets the value of a field in an object.
- **`GetUnixTimestamp():long`** - Gets the current Unix timestamp.
- **`GetUnixTimestampMilliseconds():long`** - Gets the current Unix timestamp in milliseconds.
- **`GetTimeInTimezone(string timeZoneId):DateTime`** - Gets the current time in the specified timezone.
- **`TrimStart(string text, string textToTrim, bool caseInsensitive):string`** - Trims the specified text from the start of a string, with an option for case-insensitive comparison.
---
#### *SystemInfo*
- **`GetCpuInfo():string`** - Retrieves information about the computer's CPU.
- **`GetProcessorCount():int`** - Gets the number of processors on the computer.
- **`GetTotalVirtualMemory():long`** - Gets the total amount of virtual memory.
- **`MEMORYSTATUSEX`** - Represents extended memory status information.
- **`GlobalMemoryStatusEx(MEMORYSTATUSEX lpBuffer):bool`** - Retrieves information about the computer's memory status.
- **`GetTotalPhysicalMemory():ulong`** - Gets the total physical memory of the computer.
- **`GetGraphicsDeviceNames():string[]`** - Retrieves the names of graphics devices on the computer.
- **`GetTotalDiskSpace(string driveName):long`** - Gets the total disk space of the specified drive.
- **`GetOperatingSystemName():string`** - Gets the name of the operating system.
- **`GetOperatingSystemVersion():string`** - Gets the version of the operating system.
- **`GetOperatingSystemArchitecture():string`** - Gets the architecture of the operating system.
- **`GetUserName():string`** - Gets the name of the currently logged-in user.
- **`GetComputerName():string`** - Gets the name of the computer.
- **`GetUserLanguage():string`** - Gets the language of the currently logged-in user.
- **`GetApplicationName():string`** - Gets the name of the application.
- **`GetApplicationVersion():string`** - Gets the version of the application.
---
#### *File*
- **`ReadFile(string path):string?`** - Reads the contents of a text file and returns the content as a string.
- **`ReadBinaryFile(string path):byte[]`** - Reads the contents of a binary file and returns the data as a byte array.
- **`Compress(byte[] data):byte[]`** - Compresses a byte array using a compression algorithm.
- **`Decompress(byte[] data):byte[]`** - Decompresses a byte array that was previously compressed.
- **`WriteFile(string? path, string contents):bool`** - Writes the specified content to a text file. If the file already exists, it overwrites the content.
- **`WriteBinaryFile(string? path, byte[] contents):bool`** - Writes the specified byte array to a binary file. If the file already exists, it overwrites the content.
- **`CopyFile(string source, string destination):bool`** - Copies a file from the source path to the destination path.
- **`MoveFile(string source, string destination):bool`** - Moves a file from the source path to the destination path.
- **`MoveDirectory(string source, string destination):bool`** - Moves a directory and its contents from the source path to the destination path.
- **`DeleteFile(string path):bool`** - Deletes a file from the specified path.
- **`DeleteDirectory(string path):bool`** - Deletes a directory and its contents from the specified path.
- **`GetFileSize(string path):long`** - Retrieves the size of the file in bytes.
- **`GetFileCreationTime(string path):DateTime`** - Retrieves the creation time of the file.
- **`GetFileLastAccessTime(string path):DateTime`** - Retrieves the last access time of the file.
- **`GetFileLastWriteTime(string path):DateTime`** - Retrieves the last write time of the file.
- **`GetFileMd5(string path):string`** - Calculates and returns the MD5 hash of the file content.
- **`ZipDirectory(string directory, string path):bool`** - Compresses an entire directory and its contents into a zip file.
- **`ExtractZip(string zip, string directory):bool`** - Extracts the contents of a zip file into the specified directory.
---
#### *Network*
- **`IsConnectedToInternet():bool`** - Check if the device is connected to the internet.
- **`Ping(string host):bool`** - Ping the specified host to check for network connectivity.
- **`IsSecureConnection(string url):bool`** - Determine if the connection to the given URL is secure (HTTPS).
- **`GetPublicIpAddress():Task<string>`** - Asynchronously retrieve the public IP address of the device.
- **`IsPortOpen(int port):bool`** - Check if the specified port is open on the device.
- **`GetPlain(string url):Task<string>`** - Asynchronously retrieve the content of the specified URL as plain text.
- **`GetBinary(string url):Task<byte[]>`** - Asynchronously retrieve the content of the specified URL as binary data.
- **`DownloadFileAsync(string url, string path):Task<bool>`** - Asynchronously download a file from the specified URL and save it to the specified path.
- **`PostJson(string url, object data):object`** - Send a POST request with JSON data to the specified URL and return the response object.
- **`GetBaseDomain(string domainName):string`** - Extract the base domain from the given domain name.
---
#### *Services*
- **`SendDiscordWebhook(string webhookUrl, string username, string avatarUrl, string content):bool`** - Sends a Discord webhook with the specified parameters and returns a boolean indicating success.
---
#### *Logging*
##### Error
- **`Log(string message, Exception exception, string file, bool append, bool includeStackTrace, bool includeTimestamp):bool`** - Logs an error message along with details like the exception, file, and additional options.
##### Debug
- **`Log(string message, string file, bool append, bool includeTimestamp):bool`** - Logs a debug message along with details like the file and additional options.