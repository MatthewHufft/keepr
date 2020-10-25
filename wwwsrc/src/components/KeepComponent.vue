<template>
  <div class="card col-3">
    <h3>{{keepProp.Name}}</h3>
    <img :src="keepProp.Img">
  </div>
</template>

<script>
export default {
  name: "",
  mounted(){

  },
  data(){
    return{}
  },
  computed:{
    
  },
  methods:{

  },
  props: ["keepProp"],
  components:{}
}
</script>

<style>

</style>