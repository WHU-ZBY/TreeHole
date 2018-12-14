// pages/List/create/create.js
const app = getApp();
Page({

  /**
   * 页面的初始数据
   */
  data: {
    re_content:'',
    wxid:'1111',

  },
  bindTextAreaBlur: function (e) {
    var that=this;
    console.log(e.detail.value)
    that.setData({
      re_content: e.detail.value,
    })
  },    
  onPostTap:function()
  {

    var that=this;
    wx.request({
      url: 'https://andyfool.com/file/Upload/UpMessage?name=' + app.globalData.userInfo.nickName+'&content='+this.data.re_content+'&wxId='+this.data.wxid+'v&region=1&imageId=1',//仅为示例，并非真实的接口地址
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
    wx.showToast({
      title: '发送成功',
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