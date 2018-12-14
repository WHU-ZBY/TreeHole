

Page({

  /**
   * 页面的初始数据
   */
  data: {
    datalist: []

  },
  onPostTap: function (event) {
    var listId = event.currentTarget.dataset.listid;
    // console.log("on post id is" + listId);
    wx.navigateTo({
      url: "../List/list-details/list-details?id=" + listId
    })
  },
  onLoad:function(options)
  {
    var that=this;
    wx.request({
      url: 'https://andyfool.com/file/Get/GetAllMessage', //仅为示例，并非真实的接口地址
      data: {
      }, 
      method:'Get',
      header: {
        'content-type': 'application/json' // 默认值
      },
      success(res) {
        console.log(res.data)
        var object = res.data;
        that.setData({
          'datalist': object,
        });
      }
    })
  }
})