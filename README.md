# GzsTool
C# Fox Engine dat/qar, fpk, fpkd, pftxs and sbp unpacker/repacker
 
[![Build status](https://ci.appveyor.com/api/projects/status/eqetqq6fdggc964b?svg=true)](https://ci.appveyor.com/project/Atvaark/gzstool)
Requirements
--------
```
Microsoft .NET Framework 4.5
```
 
Usage
--------
 
```
GzsTool file_path|folder_path
```

Options
-------
-OutputHashes or -o (case insensitive)
Writes the PathCode64 and ExtensionCode64 hashes for files in Qar archive to <fileName>_pathHashes.txt / _extensionHashes.txt, 
For fpk files will write FilePath Md5Hash (if MD5(FilePath) does not match Md5Hash), to <filename>_FilePath_Md5HashText.txt (same mgsv-lookup-strings hash_types identification for hashwrangler validation), for fpk_dictionary.
Will exit without extracting files.
 
Examples
--------

Unpacking a dat file. This will unpack all files to the folder called "file_name" and will create a "file_name.dat.xml" file.
```
GzsTool file_path.dat
```
 
Unpacking an fpk/fpkd file. This will unpack all files to the folder called "file_name_fpk/file_name_fpkd" and will create a "file_name.fpk.xml/file_name.fpkd.xml" file.
```
GzsTool file_path.fpk
GzsTool file_path.fpkd
```

Unpacking a pftxs file. This will unpack all files to the folder called "file_name_pftxs" and will create a "file_name.pftxs.xml" file.
```
GzsTool file_path.pftxs
```

Unpacking a sbp file. This will unpack all files to the folder called "file_name_sbp" and will create a "file_name.sbp.xml" file.
```
GzsTool file_path.sbp
```
 
Unpacking all fpk and fpkd files in a folder. This will unpack all files to their respective folders and create the respective xml files. 
```
GzsTool folder_path
```

Repacking a dat file. This will create the "file_name.dat" archive.
```
GzsTool file_path.dat.xml
```

Repacking an fpk/fpkd file. This will create the "file_name.fpk/file_name.fpkd" archive.
```
GzsTool file_path.fpk.xml
GzsTool file_path.fpkd.xml
```

Repacking a pftxs file. This will create the "file_name.pftxs" archive.
```
GzsTool file_path.pftxs.xml
```

Remarks
--------
* Repacking a dat file without changes will result in a smaller file. This is due to the tool not reencrypting formerly encrypted files and thereby not requiring to store the decryption keys.
* Unpacking Ground Zeroes g0s and pftxs files will only work with [v0.2 (Ground Zeroes)](https://github.com/Atvaark/GzsTool/releases/tag/v0.2)
