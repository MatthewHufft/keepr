<template>
  <div class="card col-3">
    <i class="fa fa-times text-danger" v-if="profile.id == keepProp.creatorId" aria-hidden="true" role="button" @click="deleteKeep"></i>
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
    profile(){
      return this.$store.state.profile
    }
  },
  methods:{
    deleteKeep(){
     this.$store.dispatch("deleteKeep", this.keepProp.id)
    }
  },
  props: ["keepProp"],
  components:{}
}
</script>

<style>

</style>