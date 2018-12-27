App({
  globalData: {
    userInfo: null,
    appid: '',//appid需自己提供，此处的appid我随机编写
    secret: '',//secret需自己提供，此处的secret我随机编写
    userName:'默认',
    userImage:'',
    num:'1',
    wxid:'123'
  },
  listData:{},
  replyData:{},
    onLaunch: function () {
    // 展示本地存储能力
    var logs = wx.getStorageSync('logs') || []
    wx.setStorageSync('logs', logs)

    // 获取用户信息
    wx.getSetting({
      success: res => {
        if (res.authSetting['scope.userInfo']) {
          // 已经授权，可以直接调用 getUserInfo 获取头像昵称，不会弹框
          wx.getUserInfo({
            success: res => {
              // 可以将 res 发送给后台解码出 unionId
              this.globalData.userInfo = res.userInfo
              console.log(res.userInfo)

              // 由于 getUserInfo 是网络请求，可能会在 Page.onLoad 之后才返回
              // 所以此处加入 callback 以防止这种情况
              if (this.userInfoReadyCallback) {
                this.userInfoReadyCallback(res)
              }
            }
          })
        }
      }
    })
  },
  onLaunch: function () {
    //云开发初始化
    wx.cloud.init({
      env: 'test-9ff899',
      traceUser: true
    })
  }
  })