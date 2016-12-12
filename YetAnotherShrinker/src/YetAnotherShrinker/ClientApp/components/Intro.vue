<template>
  <div class="intro">
    <h1 class="app-title">{{ appTitle }}</h1>
  </div>
</template>

<script>
export default {
  name: 'intro',
  data () {
    return {
      appTitle: 'YetAnotherShrinker',
    }
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