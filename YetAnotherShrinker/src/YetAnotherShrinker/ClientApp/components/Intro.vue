<template>
  <div class="intro" v-md-theme="'apptheme'">
    <h1 class="app-title">{{ appTitle }}</h1>

    <div class="container">
      <div class="row">
        <div class="eight columns offset-by-two">
          <h4>Shrink a URL</h4>
          <form novalidate @submit.stop.prevent="submit">
            <md-input-container>
              <label>Initial value</label>
              <md-input v-model="initialValue"></md-input>
            </md-input-container>

            <md-input-container>
              <label>With label</label>
              <md-input placeholder="My nice placeholder"></md-input>
            </md-input-container>

            <md-input-container md-inline>
              <label>Inline field</label>
              <md-input></md-input>
            </md-input-container>

            <md-input-container>
              <label>Number</label>
              <md-input type="number"></md-input>
            </md-input-container>

            <md-input-container>
              <label>Textarea</label>
              <md-textarea></md-textarea>
            </md-input-container>

            <md-input-container>
              <label>Disabled</label>
              <md-input disabled></md-input>
            </md-input-container>
          </form>
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
        msgData: ''
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