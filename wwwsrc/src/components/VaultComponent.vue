<template>
<div class="col-12 col-sm-4 col-md-3 col-lg-2 mb-4 ">
  <div class="card vault-card border-0 p-3 text-center" @click="openVault" >
    <h4 class="text-light">{{vaultProp.name}}</h4>
    <img class="card-img" src="../assets/vaultclosed.png" alt="">
    <div class="overlay p-3 hide">
      <h4 class="text-light">{{vaultProp.name}}</h4>
      <img class="overlay-img hide" src="../assets/vault.png" alt="">
    </div>
    <!-- <i class="fa fa-times text-danger" v-if="this.$route.params.profileId == vaultProp.creatorId" aria-hidden="true" role="button" @click="deleteVault"></i> -->
  </div>
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
.card-img{
  width:100%;
  height: auto;
}
.overlay-img{
  width:100%;
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
  animation-name: fadeIn;
  animation-duration:300ms;
  width:100%;
  height:100%;  
}

.vault-card:hover .overlay{
  z-index: 2;
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

@keyframes fadeIn{
  0% {filter: opacity(0%);}
  25% {filter: opacity(25%);}
  50% {filter: opacity(50%);}
  75% {filter: opacity(75%);}
  100% {filter: opacity(100%);}
}

</style>