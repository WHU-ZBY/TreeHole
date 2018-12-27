
Page({

  /**
   * 页面的初始数据
   */
  data: {

  },


  onPostTap: function (event) {
    var listId = event.currentTarget.dataset.listid;
     console.log("on region id is" + listId);
    wx.navigateTo({
      url: "../List/List?id=" + listId
    })
  },

})