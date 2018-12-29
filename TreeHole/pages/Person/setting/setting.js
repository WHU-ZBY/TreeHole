// pages/Person/setting/setting.js
const app = getApp();
var userList=require('../../../data/mydata.js')
Page({

  /**
   * 页面的初始数据
   */
  data: {
    concent:''

  },
  bindTextAreaBlur: function (e) {
    console.log(e.detail.value)         //打印结果”是我是一个textarea”
    this.setData({
      concent: e.detail.value,
    })
  },
  sendRequest:function(){
    var that = this;
    wx.request({
      url: 'https://andyfool.com/file/Upload3/UploadId?name=' + app.globalData.userName + '&imageid=' + app.globalData.num + '&wxid=' + app.globalData.wxid,
      data: {

      },
      method: 'Post',
      header: {
        'content-type': 'application/json' // 默认值
      },
      success(res) {
        console.log(res.data)
      }
    })
  },
  fabiao: function (e) {

    this.setData({
      focus: 'false',
      concent1: this.data.concent,
    })
    app.globalData.userName = this.data.concent;
    console.log(this.data.concent),
      console.log(app.globalData.userName)  //打印结果  
   this.sendRequest();
    wx.showToast({
      title: '修改成功',
      icon: 'success',
      duration: 2000
    })
    setTimeout(function () {
      wx.navigateBack();
      //要延时执行的代码
    }, 500) //延迟时间 这里是1秒
  },
  onPostTap1: function (event) {
    app.globalData.num =0;
    console.log(app.globalData.num);
    this.sendRequest();
    wx.showToast({
      title: '修改成功',
      icon: 'success',
      duration: 2000
    })
    setTimeout(function () {
      wx.navigateBack();
      //要延时执行的代码
    }, 500) //延迟时间 这里是1秒
  },
  onPostTap2: function (event) {
    app.globalData.num = 1;
    console.log(app.globalData.num);
    this.sendRequest();
    wx.showToast({
      title: '修改成功',
      icon: 'success',
      duration: 2000
    })
    setTimeout(function () {
      wx.navigateBack();
      //要延时执行的代码
    }, 500) //延迟时间 这里是1秒
  },
  onPostTap3: function (event) {
    app.globalData.num = 2;
    console.log(app.globalData.num);
    this.sendRequest();
    wx.showToast({
      title: '修改成功',
      icon: 'success',
      duration: 2000
    })
    setTimeout(function () {
      wx.navigateBack();
      //要延时执行的代码
    }, 500) //延迟时间 这里是1秒
  },
  onPostTap4:function (event) {
    app.globalData.num = 3;
    console.log(app.globalData.num);
    this.sendRequest();
    wx.showToast({
      title: '修改成功',
      icon: 'success',
      duration: 2000
    })
    setTimeout(function () {
      wx.navigateBack();
      //要延时执行的代码
    }, 500) //延迟时间 这里是1秒
  },
  onPostTap5: function (event) {
    app.globalData.num = 4;
    console.log(app.globalData.num);
    this.sendRequest();
    wx.showToast({
      title: '修改成功',
      icon: 'success',
      duration: 2000
    })
    setTimeout(function () {
      wx.navigateBack();
      //要延时执行的代码
    }, 500) //延迟时间 这里是1秒
  },
  onPostTap6: function (event) {
    app.globalData.num = 5;
    console.log(app.globalData.num);
    this.sendRequest();
    wx.showToast({
      title: '修改成功',
      icon: 'success',
      duration: 2000
    })
    setTimeout(function () {
      wx.navigateBack();
      //要延时执行的代码
    }, 500) //延迟时间 这里是1秒
  },


})