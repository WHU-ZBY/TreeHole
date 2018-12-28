// pages/List/create/create.js
const app = getApp();
Page({

  /**
   * 页面的初始数据
   */
  data: {
    re_content:'',
    wxid:'',
    region:'1',

  },
  onLoad: function (option) {
    var listId = option.id;
    console.log("aa");
    console.log(listId);
    console.log("aa");
    this.setData({
      region:listId,
      wxid:app.globalData.wxid,
    })
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
    console.log("aa");
    console.log(this.data.region);
    console.log("aa");
    var that=this;
    wx.request({
      url: 'https://andyfool.com/file/Upload1/UpMessage?name=' + app.globalData.userName+'&content='+this.data.re_content+'&wxId='+this.data.wxid+'&region='+this.data.region+'&imageId='+app.globalData.num,
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
    }, 500) //延迟时间 这里是1秒
  }, 
 

})