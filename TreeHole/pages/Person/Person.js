var listData = require('../../data/image.js')
var app = getApp();
Page({

  data: {
    name:'',
    imageName:'',
    _num:'1',
    datalist:''

  },
  
  onLoad: function () {
    var that = this;
    wx.request({
      url: 'https://andyfool.com/file/Get4/GetId?wxid=' + app.globalData.wxid,//仅为示例，并非真实的接口地址
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
        app.globalData.userName=object.name;
        app.globalData.num=object.imageid;
      }
    }),
    this.setData({
      _num:app.globalData.num,
      name:app.globalData.userName,
      imageName: listData.imageLocal[this.data._num].local,
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