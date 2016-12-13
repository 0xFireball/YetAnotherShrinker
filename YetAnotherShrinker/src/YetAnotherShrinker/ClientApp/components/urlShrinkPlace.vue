<template>
  <div class="urlShrinkPlace">
    <div class="container">
      <div class="row">
        <div class="eight columns offset-by-two">
          <h4>Shrink a URL</h4>
          <form novalidate @submit.stop.prevent="submit">
            <md-input-container>
              <label>Target URL</label>
              <md-input type="url" placeholder="http://example.com/" v-model="tUrl"></md-input>
            </md-input-container>
            <input type="submit" class="invisible"></input>
          </form>
          <md-button class="space-v md-raised md-primary" :disabled="!shrinkEnabled" v-on:click="shrinkUrl">Shrink</md-button>
        </div>
      </div>

      <md-dialog-alert :md-content-html="completedAlert.content" :md-ok-text="completedAlert.ok" ref="completedDialog">
      </md-dialog-alert>
    </div>
  </div>
</template>

<script>
import axios from 'axios'

let axiosRequestConfig = {
  validateStatus: function (status) {
    return status >= 200 && status < 500
  }
}

export default {
  name: 'urlShrinkPlace',
  data () {
    return {
      tUrl: '',
      shrinkEnabled: true,
      completedAlert: {
        content: '.',
        ok: 'Cool'
      }
    }
  },
  methods: {
    shrinkUrl: function () {
      // shrink the url
      let vm = this
      vm.shrinkEnabled = false
      vm.completedAlert.content = '<h3>Loading</h3>'

      // basic validate
      if (!vm.tUrl) {
        vm.completedAlert.content = '<h2>Error</h2><p>URL cannot be empty.</p>'
        vm.$refs.completedDialog.open();
        vm.shrinkEnabled = true
        return
      }

      axios.post('/x/shrink', {
        url: vm.tUrl
      }, axiosRequestConfig)
        .then((response) => {
          if (response.status === 200) {
            // success
            let shrunkUrlInfo = response.data.shrunkUrl
            let shrunkLink = shrunkUrlInfo.shrunkPath
            let shrunkLinkUrl = window.document.location.href + 'r/' + shrunkLink
            vm.completedAlert.content = '<h2>Congratulations!</h2><p>Link has been shrunk!</p><code>' 
              + shrunkLinkUrl 
              + '</code>'
            vm.$refs.completedDialog.open();
          } else if (response.status === 400) {
            // bad request
            vm.completedAlert.content = '<h2>Error</h2><p>Please make sure the URL is valid.</p>'
            vm.$refs.completedDialog.open();
          }
          vm.shrinkEnabled = true
        })
        .catch((error) => {
          if (error) {
            // console.log(error)
          }
          vm.shrinkEnabled = true
        })
    }
  },
  mounted: function () {
  }
}
</script>

<style scoped>

</style>