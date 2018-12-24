
var app = getApp();
Page({
  data: {
    imagelocal:''

  },
  onLoad: function(option) {
    var listId = option.id;
    var postData = app.listData[listId];
    this.setData({
      listDetails: postData,
      imagelocal: "/images/list/"+postData.imageid+".png"
    })
    console.log(postData.imageid),
  console.log(this.data.imagelocal)
  }
})