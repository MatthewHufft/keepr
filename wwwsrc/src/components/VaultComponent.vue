<template>
  <div class="card vault-comp" @click="openVault" >
    <h3>{{vaultProp.name}}</h3>
    <i class="fa fa-times text-danger" v-if="this.$route.params.profileId == vaultProp.creatorId" aria-hidden="true" role="button" @click="deleteVault"></i>
    <img src="//placehold.it/200x200" alt="">
  </div>
</template>

<script>
export default {
name: "",
  mounted(){
  },
  data(){
    return{
      
    }
  },
  computed:{
    profile(){
      return this.$store.state.activeProfile;
    },
  },
  methods:{
    deleteVault(){
      this.$store.dispatch("deleteVault", this.vaultProp.id)
    },
    openVault(){
      this.$router.push({name:'VaultDetails', params:{vaultId: this.vaultProp.id}})
    }
  },
  props: ["vaultProp"],
  components:{}
}
</script>

<style>

</style>