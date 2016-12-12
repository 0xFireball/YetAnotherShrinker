<template>
  <div id="app">
    <!--<img src="./assets/logo.png">-->
    <intro></intro>
  </div>
</template>

<script>
import Intro from './components/Intro'

export default {
  name: 'app',
  data: function () {
    return {
      appTitle: 'YetAnotherShrinker'
    }
  },
  components: {
    Intro
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
</style>