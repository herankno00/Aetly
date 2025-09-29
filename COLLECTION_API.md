# Collection API Documentation

## Overview
The SjlController (收藏列表控制器) manages a collection system for collectible items with properties like name, price, and collection count.

## Endpoints

### GET /api/sjl
Returns image files from the `./images/dd/` directory.

**Parameters:**
- `path` (string): The filename of the image to retrieve

**Returns:** JPEG image file

### POST /api/sjl
Retrieves paginated collection data.

**Parameters:**
- `index` (int): Page number (1-based indexing)

**Returns:** JSON array of Collection objects

**Example Response:**
```json
[
  {
    "name": "古董花瓶",
    "price": 1288.00,
    "collection_count": 3,
    "image_path": "vase1.jpg",
    "description": "清代青花瓷花瓶",
    "created_time": "2024-08-30T10:30:00"
  }
]
```

### PUT /api/sjl
Adds a new collection item.

**Request Body:**
```json
{
  "name": "收藏品名称",
  "price": 999.99,
  "collection_count": 1,
  "image_path": "image.jpg",
  "description": "收藏品描述"
}
```

**Returns:** Success or error message

## Collection Model

| Field | Type | Description |
|-------|------|-------------|
| ID | int | Auto-generated unique identifier |
| name | string | 收藏品名称 (Collection item name) |
| price | decimal | 价格 (Price) |
| collection_count | int | 收藏数量 (Collection count) |
| image_path | string | 图片路径 (Image path) |
| description | string | 描述 (Description) |
| created_time | DateTime | 创建时间 (Creation time) |

## Features

- **Pagination**: Returns 6 items per page
- **Error Handling**: Logs errors to the system error log
- **Data Validation**: Validates required fields
- **Sample Data**: Pre-populated with example collectible items including antiques, books, jade, coins, paintings, and ceramics