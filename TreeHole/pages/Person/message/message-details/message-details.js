
var app = getApp();
Page({
  data: {
    re_reply: '',
    wxid: '',
    replytowx:'',
    re_id:'',
  },
  onLoad: function (option) {
    var listId = option.id;

    var postData = app.replyData[listId];
    console.log(option.id + "ss");
    console.log(listId+"ss");
    console.log(app.replyData[listId]);
    this.setData({
      listDetails: postData,
      re_id: listId,
    })
  },
  bindTextAreaBlur: function (e) {
    var that = this;
    console.log(e.detail.value)
    that.setData({
      re_content: e.detail.value,
    })
  }, 
  onPostTap: function () {
    console.log("aa");
    console.log(this.data.region);
    console.log("aa");
    var that = this;
    wx.request({
      url: 'https://andyfool.com/file/Upload2/UpReply?name=' + app.globalData.userName + '&content=' + this.data.re_content + '&wxId=' + app.globalData.wxid + '&replyTo=null' + '&imageId=' + 1 + '&replytowx=' + app.replyData[this.data.re_id].wxid,//this.data.replytowx
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