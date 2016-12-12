<template>
  <div class="intro" v-md-theme="'apptheme'">
    <h1 class="app-title">{{ appTitle }}</h1>

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
  name: 'intro',
  data () {
    return {
        appTitle: 'YetAnotherShrinker',
        msgData: '',
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

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .intro {
    margin-top: 15%;
  }
  
  .app-title {
    font-size: 6rem;
    letter-spacing: 0.1rem;
    font-weight: 300;
  }
</style>