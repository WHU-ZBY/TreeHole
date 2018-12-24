var listData = require('../../data/image.js')
var app = getApp();
Page({

  data: {
    name:'',
    imageName:'',
    num:''

  },
  
  onLoad: function () {
    this.setData({
      name:app.globalData.userName,
      imageName:listData.imageLocal[4].local
    });
  },
  onShow:function(){
 this.onLoad();
  },
  onPullDownRefresh: function () {
    wx.showNavigationBarLoading() //在标题栏中显示加载
    //模拟加载
    setTimeout(function () {
      // complete
      wx.hideNavigationBarLoading() //完成停止加载
      wx.stopPullDownRefresh() //停止下拉刷新
    }, 1500);
    this.onLoad();
  },
})