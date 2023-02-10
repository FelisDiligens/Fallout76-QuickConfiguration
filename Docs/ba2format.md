# BA2 file description

I reverse-engineered the files a bit and took the information from here: https://github.com/digitalutopia1/BA2Lib/blob/master/BA2Lib/BA2.h

- [BA2 file description](#ba2-file-description)
  - [Header](#header)
  - [File header](#file-header)
    - [General file header](#general-file-header)
    - [Texture header](#texture-header)
      - [Texture header: Chunks](#texture-header-chunks)
  - [Files](#files)
  - [File name table](#file-name-table)


## Header

| Bytes       | Type    | Description                              |
| ----------- | ------- | ---------------------------------------- |
| 0x00 - 0x03 | char[4] | Magic Number ("BTDX")                    |
| 0x04 - 0x07 | uint32  | Version                                  |
| 0x08 - 0x0B | char[4] | Archive format (either "GNRL" or "DX10") |
| 0x0C - 0x0F | uint32  | Number of files                          |
| 0x10 - 0x17 | uint64  | Offset to file name table                |

24 Bytes

## File header

Each file has a header, starting at 0x18. The byte ranges in this table are relative to the start of a file header.

### General file header

This header is used when the format is "GNRL".

| Bytes       | Type    | Description                             |
| ----------- | ------- | --------------------------------------- |
| 0x00 - 0x03 | uint32  | nameHash                                |
| 0x04 - 0x07 | char[4] | File extension (null terminated string) |
| 0x08 - 0x0B | uint32  | dirHash                                 |
| 0x0C - 0x0F | uint32  | flags                                   |
| 0x10 - 0x17 | uint64  | offset                                  |
| 0x18 - 0x1B | uint32  | Pack size                               |
| 0x1C - 0x1F | uint32  | Full size                               |
| 0x20 - 0x23 | uint32  | align                                   |

36 Bytes

### Texture header

This header is used when the format is "DX10".

| Bytes       | Type    | Description                             |
| ----------- | ------- | --------------------------------------- |
| 0x00 - 0x03 | uint32  | nameHash                                |
| 0x04 - 0x07 | char[4] | File extension (null terminated string) |
| 0x08 - 0x0B | uint32  | dirHash                                 |
| 0x0C        | uint8   | unk8                                    |
| 0x0D        | uint8   | Number of chunks                        |
| 0x0E - 0x0F | uint16  | chunkHdrLen                             |
| 0x10 - 0x11 | uint16  | height                                  |
| 0x12 - 0x13 | uint16  | width                                   |
| 0x14        | uint8   | numMips                                 |
| 0x15        | uint8   | format                                  |
| 0x16-0x17   | uint16  | unk16                                   |

24 Bytes

#### Texture header: Chunks

Each texture header has one or more chunks. The byte ranges in this table are relative to the end of the texture header.

| Bytes       | Type   | Description |
| ----------- | ------ | ----------- |
| 0x00 - 0x07 | uint64 | offset      |
| 0x08 - 0x0B | uint32 | Pack size   |
| 0x0C - 0x0F | uint32 | Full size   |
| 0x10 - 0x11 | uint16 | startMip    |
| 0x12 - 0x13 | uint16 | endMip      |
| 0x14 - 0x17 | uint32 | align       |

24 Bytes

## Files

The file contents.

## File name table

| Bytes                     | Type    | Description      |
| ------------------------- | ------- | ---------------- |
| 0x00                      | uint8   | File name length |
| 0x01                      | uint8   | always 0         |
| 0x02 - (file name length) | char[n] | File name        |
