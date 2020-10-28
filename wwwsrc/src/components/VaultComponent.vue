<template>
  <div class="card vault-card border-0" @click="openVault" >
    <img class="card-img" src="../assets/vault.png" alt="">
    <div class="deets d-flex text-light flex-column align-items-center overlay">
      <h3>{{vaultProp.name}}</h3>

    </div>
    <!-- <i class="fa fa-times text-danger" v-if="this.$route.params.profileId == vaultProp.creatorId" aria-hidden="true" role="button" @click="deleteVault"></i> -->
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
.hide{
  display: none;
}
.vault-card{
  position: relative;
  display: inline-block;
  border-radius: 10px;
  background: #252627;
  box-shadow:     7px 7px 14px #171818, 
             -7px -7px 14px #333436;
}

.overlay{
  transition: 400ms;
}
.vault-card:hover .overlay{
  width:100%;
  height:100%;
  background:rgba(0,0,0,.5);
  border-radius: 10px;
  position:absolute;
  top:0;
  left:0;
  display:inline-block;
  cursor: pointer;
}

.vault-card:hover .hide{
  display: inline-block
}
.deets{
  position: absolute;
  z-index: 2;
}

</style>