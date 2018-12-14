var listData = require('../../data/mydata.js')
var app = getApp();
Page({

  data: {

  },
  
  onLoad: function () {
    this.setData({
      myMessage:listData.postMyMessage
    });
  }

})