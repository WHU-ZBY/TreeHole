const app=getApp();
Page({
  data:{
    datalist: []
  },
  onLoad:function(){

    var that = this;
    wx.request({
      url: 'https://andyfool.com/file/test/GetAllMessage', //仅为示例，并非真实的接口地址
      data: {
      },
      method: 'Get',
      header: {
        'content-type': 'application/json' // 默认值
      },
      success(res) {
        console.log(res.data)
        var object = res.data;
        that.setData({
          'datalist': object,
        });
        app.listData=object;
        //console.log(app.listData)
      }
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
  },

  onPostTap: function (event) {
    var listId = event.currentTarget.dataset.listid;
    console.log("on post id is" + listId);
    console.log(app.listData[listId]);

   
   wx.navigateTo({
      url: "list-details/list-details?id=" + listId
    })
  
  },

})