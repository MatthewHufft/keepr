<template>
  <div class="card col-3">
    <h3>{{keepProp.name}}</h3>
    <img :src="keepProp.img">
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