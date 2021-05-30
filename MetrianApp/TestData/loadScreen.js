isc.RestDataSource.create({
  ID: "TestRDS",
  fields: [
    { name: "Item", type: "text" },
    { name: "Price", type: "float" },
  ],
  clientOnly: true,
  cacheData: [
    { Item: "Item 1", Price: 1.0 },
    { Item: "Item 2", Price: 2.0 },
    { Item: "Item 3", Price: 3.0 },
  ],
});
isc.VLayout.create({
  members: [
    {
      ID: "AddBtn",
      _constructor: "IButton",
      title: "Add",
    },
    {
      _constructor: "ListGrid",
      dataSource: "TestRDS",
      autoFetchData: true,
    },
  ],
  destroy() {
    this.Super("destroy", arguments);
    TestRDS.destroy();
  },
});
