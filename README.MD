# Wavestorm.Utilities Namespace

## Utilities

### General

The `General` class in the `Wavestorm.Utilities` namespace provides a collection of general-purpose utility methods for common tasks. This class includes methods for generating UUIDs, obtaining random integers and strings, converting between strings and byte arrays, checking for null or empty values, validating email addresses and URLs, encoding and decoding strings using Base64, encrypting and decrypting strings using AES and RSA algorithms, compressing and decompressing strings using GZip, serializing and deserializing objects to and from JSON, and working with property and field values.

#### Methods:

- **GetUUID()**
  - *Description:* Generates a new UUID (Universally Unique Identifier).
  - *Returns:* The generated UUID.

- **GetRandomInt(int min, int max)**
  - *Description:* Generates a random integer between the specified minimum and maximum values.
  - *Parameters:*
    - `min`: The minimum value for the random integer.
    - `max`: The maximum value for the random integer.
  - *Returns:* The generated random integer.

- **GetRandomString(int length, bool useNumbers = false, bool useSpecialCharacters = false)**
  - *Description:* Generates a random string of the specified length, with options to include numbers and special characters.
  - *Parameters:*
    - `length`: The length of the random string.
    - `useNumbers`: (Optional) Include numbers in the random string. Default is `false`.
    - `useSpecialCharacters`: (Optional) Include special characters in the random string. Default is `false`.
  - *Returns:* The generated random string.

- **StringToByteArray(string str)**
  - *Description:* Converts a string to a byte array.
  - *Parameters:*
    - `str`: The input string.
  - *Returns:* The byte array representing the input string.

- **ByteArrayToString(byte[] bytes)**
  - *Description:* Converts a byte array to a string.
  - *Parameters:*
    - `bytes`: The input byte array.
  - *Returns:* The string representation of the input byte array.

- **IsNullOrEmpty\<T>(T input)**
  - *Description:* Checks if an input is null or empty.
  - *Parameters:*
    - `input`: The input value to check.
  - *Returns:* `true` if the input is null or empty; otherwise, `false`.

- **IsValidEmail(string email)**
  - *Description:* Checks if a string is a valid email address.
  - *Parameters:*
    - `email`: The input string to check.
  - *Returns:* `true` if the input is a valid email address; otherwise, `false`.

- **IsValidUrl(string url)**
  - *Description:* Checks if a string is a valid URL.
  - *Parameters:*
    - `url`: The input string to check.
  - *Returns:* `true` if the input is a valid URL; otherwise, `false`.

- **EncodeBase64(string plainText)**
  - *Description:* Encodes a string using Base64.
  - *Parameters:*
    - `plainText`: The input string to encode.
  - *Returns:* The Base64-encoded string.

- **DecodeBase64(string base64EncodedData)**
  - *Description:* Decodes a string using Base64.
  - *Parameters:*
    - `base64EncodedData`: The Base64-encoded string to decode.
  - *Returns:* The decoded string.

- **EncryptString(string plainText, string key)**
  - *Description:* Encrypts a string using AES.
  - *Parameters:*
    - `plainText`: The input string to encrypt.
    - `key`: The encryption key.
  - *Returns:* The encrypted string.

- **DecryptString(string cipherText, string key)**
  - *Description:* Decrypts a string using AES.
  - *Parameters:*
    - `cipherText`: The input string to decrypt.
    - `key`: The decryption key.
  - *Returns:* The decrypted string.

- **EncryptStringRSA(string plainText, string publicKey)**
  - *Description:* Encrypts a string using RSA.
  - *Parameters:*
    - `plainText`: The input string to encrypt.
    - `publicKey`: The RSA public key.
  - *Returns:* The encrypted string.

- **DecryptStringRSA(string cipherText, string privateKey)**
  - *Description:* Decrypts a string using RSA.
  - *Parameters:*
    - `cipherText`: The input string to decrypt.
    - `privateKey`: The RSA private key.
  - *Returns:* The decrypted string.

- **CompressString(string text)**
  - *Description:* Compresses a string using GZip.
  - *Parameters:*
    - `text`: The input string to compress.
  - *Returns:* The compressed string.

- **DecompressString(string compressedText)**
  - *Description:* Decompresses a string using GZip.
  - *Parameters:*
    - `compressedText`: The input string to decompress.
  - *Returns:* The decompressed string.

- **SerializeObject(object obj)**
  - *Description:* Serializes an object to a JSON string.
  - *Parameters:*
    - `obj`: The object to serialize.
  - *Returns:* The JSON string representation of the object.

- **DeserializeObject(string json)**
  - *Description:* Deserializes a JSON string to an object.
  - *Parameters:*
    - `json`: The JSON string to deserialize.
  - *Returns:* The deserialized object.

- **GetPropertyValue(object obj, string propertyName)**
  - *Description:* Gets the value of a property from an object.
  - *Parameters:*
    - `obj`: The object containing the property.
    - `propertyName`: The name of the property.
  - *Returns:* The value of the property.

- **SetPropertyValue(object obj, string propertyName, object value)**
  - *Description:* Sets the value of a property on an object.
  - *Parameters:*
    - `obj`: The object containing the property.
    - `propertyName`: The name of the property.
    - `value`: The value to set.
  - *Returns:* `true` if the property was set successfully; otherwise, `false`.

- **GetFieldValue(object obj, string fieldName)**
  - *Description:* Gets the value of a field from an object.
  - *Parameters:*
    - `obj`: The object containing the field.
    - `fieldName`: The name of the field.
  - *Returns:* The value of the field.

- **SetFieldValue(object obj, string fieldName, object value)**
  - *Description:* Sets the value of a field on an object.
  - *Parameters:*
    - `obj`: The object containing the field.
    - `fieldName`: The name of the field.
    - `value`: The value to set.
  - *Returns:* `true` if the field was set successfully; otherwise, `false`.

- **GetUnixTimestamp()**
  - *Description:* Gets the current Unix timestamp.
  - *Returns:* The current Unix timestamp.

- **GetUnixTimestampMilliseconds()**
  - *Description:* Gets the current Unix timestamp in milliseconds.
  - *Returns:* The current Unix timestamp in milliseconds.

- **GetTimeInTimezone(string timeZoneId)**
  - *Description:* Gets the current time in the specified time zone.
  - *Parameters:*
    - `timeZoneId`: The time zone ID.
  - *Returns:* The current time in the specified time zone.

---

## SystemInfo

The `SystemInfo` class in the `Wavestorm.Utilities` namespace provides methods to retrieve information about the system's hardware, operating system, and environment.

### Methods:

- **GetCpuInfo()**
  - *Description:* Gets information about the current CPU. (Windows only)
  - *Returns:* A string containing CPU information.

- **GetProcessorCount()**
  - *Description:* Gets the number of logical processors in the current system.
  - *Returns:* An integer representing the number of logical processors.

- **GetTotalVirtualMemory()**
  - *Description:* Gets the number of bytes in the operating system's committed virtual memory.
  - *Returns:* A long representing the total virtual memory in bytes.

- **GetTotalPhysicalMemory()**
  - *Description:* Gets the total physical memory installed on the system. (Windows only)
  - *Returns:* A ulong representing the total physical memory in bytes.

- **GetGraphicsDeviceNames()**
  - *Description:* Gets the user's GPU (graphics processing unit) names. (Windows only)
  - *Returns:* An array of strings containing GPU names.

- **GetTotalDiskSpace([Optional] string driveName)**
  - *Description:* Gets the total disk space of the specified drive or all drives combined.
  - *Parameters:*
    - `driveName` (Optional): The name of the drive.
  - *Returns:* A long representing the total disk space in bytes.

- **GetOperatingSystemName()**
  - *Description:* Gets the name of the operating system running on the computer.
  - *Returns:* A string representing the operating system name.

- **GetOperatingSystemVersion()**
  - *Description:* Gets the version of the operating system running on the computer.
  - *Returns:* A string representing the operating system version.

- **GetOperatingSystemArchitecture()**
  - *Description:* Gets the architecture of the operating system running on the computer.
  - *Returns:* A string representing the operating system architecture.

- **GetUserName()**
  - *Description:* Gets the name of the user who is currently logged in.
  - *Returns:* A string representing the user name.

- **GetComputerName()**
  - *Description:* Gets the name of the computer.
  - *Returns:* A string representing the computer name.

- **GetUserLanguage()**
  - *Description:* Gets the user's language.
  - *Returns:* A string representing the user's language.

- **GetApplicationName()**
  - *Description:* Gets the name of the application.
  - *Returns:* A string representing the application name.

- **GetApplicationVersion()**
  - *Description:* Gets the version of the application.
  - *Returns:* A string representing the application version.

---

## Network

The `Network` class in the `Wavestorm.Utilities` namespace provides utility methods related to network operations.

### Methods:

- **IsConnectedToInternet()**
  - *Description:* Checks if the device is connected to the internet.
  - *Returns:* True if the device is connected to the internet, false otherwise.

- **PingHost(string host)**
  - *Description:* Pings a host to check if it is reachable.
  - *Parameters:*
    - `host`: The host to ping.
  - *Returns:* True if the host is reachable, false otherwise.

- **IsSecureConnection(string url)**
  - *Description:* Checks if a URL has a secure (HTTPS) connection.
  - *Parameters:*
    - `url`: The URL to check.
  - *Returns:* True if the URL has a secure connection, false otherwise.

- **GetPublicIpAddress()**
  - *Description:* Gets the public IP address of the device.
  - *Returns:* A string representing the public IP address of the device.
  - *Note:* This method requires an internet connection.

- **IsPortOpen(int port)**
  - *Description:* Checks if a port is open.
  - *Parameters:*
    - `port`: The port to check.
  - *Returns:* True if the port is open, false otherwise.

- **DownloadFile(string url, string path)**
  - *Description:* (Not implemented yet) Downloads a file from the specified URL and saves it to the specified path.
  - *Parameters:*
    - `url`: The URL of the file to download.
    - `path`: The path where the downloaded file will be saved.
  - *Note:* This method is marked as not implemented, and a TODO comment suggests that it needs implementation.

---

## Files Class

The `Files` class in the `Wavestorm.Utilities` namespace provides utility methods for file and directory operations.

### Methods:

- **ReadFile(string path)**
  - *Description:* Reads the contents of a text file from the specified path.
  - *Parameters:*
    - `path`: The path to the file.
  - *Returns:* The contents of the file as a string.

- **ReadBinaryFile(string path)**
  - *Description:* Reads the contents of a binary file from the specified path.
  - *Parameters:*
    - `path`: The path to the file.
  - *Returns:* The contents of the file as a byte array.

- **WriteFile([Optional] string? path, string contents)**
  - *Description:* Writes the specified contents to a text file at the specified path.
  - *Parameters:*
    - `path`: The path to the file. If null, the current directory is used.
    - `contents`: The contents to write to the file.
  - *Returns:* True if the file was written successfully, false otherwise.

- **WriteBinaryFile([Optional] string? path, byte[] contents)**
  - *Description:* Writes the specified binary contents to a file at the specified path.
  - *Parameters:*
    - `path`: The path to the file. If null, the current directory is used.
    - `contents`: The binary contents to write to the file.
  - *Returns:* True if the file was written successfully, false otherwise.

- **CopyFile(string source, string destination)**
  - *Description:* Copies a file from the source path to the destination path.
  - *Parameters:*
    - `source`: The source path.
    - `destination`: The destination path.
  - *Returns:* True if the file was copied successfully, false otherwise.
  - *Note:* This method is marked with a TODO comment suggesting the need for a better and more robust implementation.

- **MoveFile(string source, string destination)**
  - *Description:* Moves a file from the source path to the destination path.
  - *Parameters:*
    - `source`: The source path.
    - `destination`: The destination path.
  - *Returns:* True if the file was moved successfully, false otherwise.
  - *Note:* This method is marked with a TODO comment suggesting the need for a better and more robust implementation.

- **MoveDirectory(string source, string destination)**
  - *Description:* Moves a directory from the source path to the destination path.
  - *Parameters:*
    - `source`: The source path.
    - `destination`: The destination path.
  - *Returns:* True if the directory was moved successfully, false otherwise.
  - *Note:* This method is marked with a TODO comment suggesting the need for a better and more robust implementation.

- **DeleteFile(string path)**
  - *Description:* Deletes a file from the specified path.
  - *Parameters:*
    - `path`: The path to the file.
  - *Returns:* True if the file was deleted successfully, false otherwise.

- **DeleteDirectory(string path)**
  - *Description:* Deletes a directory from the specified path.
  - *Parameters:*
    - `path`: The path to the directory.
  - *Returns:* True if the directory was deleted successfully, false otherwise.

- **GetFileSize(string path)**
  - *Description:* Gets the size of a file from the specified path.
  - *Parameters:*
    - `path`: The path to the file.
  - *Returns:* The size of the file in bytes.

- **GetFileCreationTime(string path)**
  - *Description:* Gets the creation time of a file from the specified path.
  - *Parameters:*
    - `path`: The path to the file.
  - *Returns:* The creation time of the file.

- **GetFileLastAccessTime(string path)**
  - *Description:* Gets the last access time of a file from the specified path.
  - *Parameters:*
    - `path`: The path to the file.
  - *Returns:* The last access time of the file.

- **GetFileLastWriteTime(string path)**
  - *Description:* Gets the last write time of a file from the specified path.
  - *Parameters:*
    - `path`: The path to the file.
  - *Returns:* The last write time of the file.

---

## Logging Class

The `Logging` class in the `Wavestorm.Utilities` namespace provides a nested `Error` class for logging error messages.

### Error

#### Methods:

- **Log(string message, Exception exception, string file = "error.log", bool append = true, bool includeStackTrace = true, bool includeTimestamp = true)**
  - *Description:* Logs an error message to a file located in the user's documents folder.
  - *Parameters:*
    - `message`: The message to log.
    - `exception`: The exception to log.
    - `file`: The file to log to (default is "error.log").
    - `append`: Whether to append to the file or overwrite it (default is true).
    - `includeStackTrace`: Whether to include the stack trace in the log (default is true).
    - `includeTimestamp`: Whether to include the timestamp in the log (default is true).
  - *Returns:* Whether the log was successful.

### Debug

#### Methods:

- **Log(string message, string file = "debug.log", bool append = true, bool includeTimestamp = true)**
  - *Description:* Logs a debug message to a file located in the user's documents folder.
  - *Parameters:*
    - `message`: The message to log.
    - `file`: The file to log to (default is "debug.log").
    - `append`: Whether to append to the file or overwrite it (default is true).
    - `includeTimestamp`: Whether to include the timestamp in the log (default is true).
  - *Returns:* Whether the log was successful.

---