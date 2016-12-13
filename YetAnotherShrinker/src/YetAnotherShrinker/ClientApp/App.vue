<template>
  <div id="app" v-md-theme="'apptheme'">
    <!--<img src="./assets/logo.png">-->
    <intro></intro>
    <urlShrinkPlace></urlShrinkplace>
    <devCredits></devCredits>
  </div>
</template>

<script>
import Intro from './components/Intro'
import urlShrinkPlace from './components/urlShrinkPlace'
import devCredits from './components/devCredits'

export default {
  name: 'app',
  data: function () {
    return {
      appTitle: 'YetAnotherShrinker'
    }
  },
  components: {
    Intro,
    urlShrinkPlace,
    devCredits
  }
}
</script>

<style>
  #app {
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }
  
  body {
    background: #f7f7f7;
  }
  
  .invisible {
    display: none;
  }
  
  .space-v {
    margin-top: 5%;
    margin-bottom: 5%;
  }
</style>