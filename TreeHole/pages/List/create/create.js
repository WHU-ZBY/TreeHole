// pages/List/create/create.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    re_content:''

  },
  bindTextAreaBlur: function (e) {
    this.setData({
      re_content: e.detail.value
    })
  },    
  onPostTap:function()
  {
    var that = this;
    wx.request({
      url: 'https://andyfool.com/file/test/UpMessage?content='+this.re_content, //仅为示例，并非真实的接口地址
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