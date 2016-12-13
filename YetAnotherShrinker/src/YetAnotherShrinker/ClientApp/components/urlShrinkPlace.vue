<template>
  <div class="urlShrinkPlace">
    <div class="container">
      <div class="row">
        <div class="eight columns offset-by-two">
          <h4>Shrink a URL</h4>
          <form novalidate @submit.stop.prevent="submit">
            <md-input-container>
              <label>Target URL</label>
              <md-input placeholder="http://example.com/" v-model="tUrl"></md-input>
            </md-input-container>
            <input type="submit" class="invisible"></input>
          </form>
          <md-button class="space-v md-raised md-primary" v-on:click="shrinkUrl">Shrink</md-button>
        </div>
      </div>
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
      tUrl: ''
    }
  },
  methods: {
    shrinkUrl: function () {
      // shrink the url
      axios.post('/x/shrink', {
        url: this.tUrl
      }, axiosRequestConfig)
        .then((response) => {
          if (response.status === 200) {
            // success
          } else if (response.status === 400) {
            // bad request
            
          }
        })
        .catch((error) => {
          if (error) {
            // console.log(error)

          }
        })
    }
  },
  mounted: function () {
  }
}
</script>

<style scoped>

</style>