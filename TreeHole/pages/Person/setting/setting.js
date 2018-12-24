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
  fabiao: function (e) {

    this.setData({
      focus: 'false',
      concent1: this.data.concent,
    })
    app.globalData.userName = this.data.concent;
    console.log(this.data.concent),
      console.log(app.globalData.userName)  //打印结果    ””  
    wx.showToast({
      title: '修改成功',
      icon: 'success',
      duration: 2000
    })
    setTimeout(function () {
      wx.navigateBack();
      //要延时执行的代码
    }, 1000) //延迟时间 这里是1秒
  },
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {

  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  }
})