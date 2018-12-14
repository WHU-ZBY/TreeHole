var replyMessage = require('../../../../data/message.js')
var app = getApp();
Page({
  data: {

  },
  onLoad: function (option) {
    var listId = option.id;
    var postData = replyMessage.postMessage[listId];
    this.setData({
      listDetails: postData
    })
  }
})