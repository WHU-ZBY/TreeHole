var imgaeID = require('../../../data/image.js')
const app = getApp();

Page({
  data: {
    datalist: [],
  },
  onLoad: function () {
    this.setData({
      
    });
    this.getRequest();
  },
  getRequest: function () {
    var that = this;
    wx.request({
      url: 'https://andyfool.com/file/Get3/MyReplies?wxid=' + app.globalData.wxid,//仅为示例，并非真实的接口地址
      data: {
      },
      method: 'Post',
      header: {
        'content-type': 'application/json' // 默认值
      },
      success(res) {
        var object = res.data;
        that.setData({
          'datalist': object,
        });
        app.replyData = object;
        console.log(app.replyData)
      }
    })
  },
  onPostTap: function (event) {
    var listId = event.currentTarget.dataset.listid;
    console.log("on post id is" + listId);
    wx.navigateTo({
      url: "message-details/message-details?id="+listId
    })
  },
  onPullDownRefresh: function () {
    wx.showNavigationBarLoading() //在标题栏中显示加载
    //模拟加载
    setTimeout(function () {
      // complete
      wx.hideNavigationBarLoading() //完成停止加载
      wx.stopPullDownRefresh() //停止下拉刷新
    }, 1500);
    this.getRequest();
  },

})