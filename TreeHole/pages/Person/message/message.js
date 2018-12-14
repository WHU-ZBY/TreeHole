var listData = require('../../../data/message.js')

Page({
  data: {

  },
  onLoad: function () {
    this.setData({
      postList: listData.postMessage
    });
  },

  onPostTap: function (event) {
    var listId = event.currentTarget.dataset.listid;
    // console.log("on post id is" + listId);
    wx.navigateTo({
      url: "message-details/message-details?id=" + listId
    })
  },

})