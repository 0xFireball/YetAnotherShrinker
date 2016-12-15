import { Line, reactiveProp } from 'vue-chartjs'

export default Line.extend({
  mixins: [reactiveProp],
  props: ['chartData', 'options'],
  mounted () {
    // Overwriting base render method with actual data.

    // Fetch data

    this.renderChart(this.chartData, this.options)
  }
})
