using System;
using Aetly.MOD;
using Aetly.Data;

// Simple test to ensure the Collection model compiles correctly
var collection = new Collection
{
    name = "Test Item",
    price = 100.50m,
    collection_count = 5,
    description = "Test Description"
};

Console.WriteLine($"Collection: {collection.name}, Price: {collection.price}, Count: {collection.collection_count}");
