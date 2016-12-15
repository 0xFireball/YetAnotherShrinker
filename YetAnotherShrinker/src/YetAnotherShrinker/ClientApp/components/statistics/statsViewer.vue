<template>
  <div class="stats-viewer">
    <statsLineGraph :data="stats.data"></statsLineGraph>
  </div>
</template>

<script>

  import statsLineGraph from './statsLineGraph'

  export default {
    data() {
      return {
        stats: {
          data: {}
        }
      }
    },
    components: {
      statsLineGraph
    },
    mounted() {
      let vm = this
      // get shrink route
      let shrinkRoute = vm.$route.params.sroute
      // use dummy data
      this.stats.data = {
        labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
        datasets: [
          {
            label: 'GitHub Commits',
            backgroundColor: '#f87979',
            data: [40, 20, 12, 39, 10, 40, 39, 80, 40, 20, 12, 11]
          }
        ]
      }
    }
  }
</script>

<style scoped>
</style>