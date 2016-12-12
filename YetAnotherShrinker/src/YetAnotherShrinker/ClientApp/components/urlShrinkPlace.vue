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
          <md-button class="space-v md-raised md-primary" @click="shrinkUrl()">Shrink</md-button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'urlShrinkPlace',
  data () {
    return {
      tUrl: ''
    }
  },
  methods: {
    shrinkUrl: function () {

    }
  },
  mounted: function () {
  }
}
</script>

<style scoped>

</style>