
var app = getApp();
Page({
  data: {

  },
  onLoad: function(option) {
    var listId = option.id;
    var postData = app.listData[listId];
    this.setData({
      listDetails: postData
    })
  }
})