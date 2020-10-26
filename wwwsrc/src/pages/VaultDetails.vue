<template>
  <div class="container-fluid d-flex">
    <KeepComponent v-for="keep in activeKeeps" :key="keep.id" :keepProp="keep"/>
  </div>
</template>

<script>
import KeepComponent from "../components/KeepComponent.vue";
export default {
name: "vault-details",
  mounted(){
      this.$store.dispatch("getActiveKeeps", this.$route.params.vaultId);
  },
  data(){
    return{}
  },
  computed:{
    activeKeeps(){
      return this.$store.state.activeKeeps;
    }
  },
  methods:{

  },
  props: ["keepProp"],
  components:{KeepComponent}
}
</script>

<style>

</style>