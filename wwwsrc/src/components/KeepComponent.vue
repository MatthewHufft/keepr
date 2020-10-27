<template>
  <div class="card keep-card">
    <div class="trans-box" role="button" data-toggle="modal" :data-target="'#keepModal'+ keepProp.id" @click="updateViewCount"></div>
    <div class="creator-deets d-flex">
      <img class="avatar " :src="keepProp.creator.picture" alt="">
      <p class="text-light ml-3 hide">{{keepProp.creator.name}}</p>
    </div>
    <img class="card-img" :src="keepProp.img" >
    <div class="modal fade" :id="'keepModal'+ keepProp.id" tabindex="-1" :aria-labelledby="'#keepModal'+ keepProp.id + 'Label'" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" :id="'#keepModal'+ keepProp.id + 'Label'">{{keepProp.name}}</h5>
            <div class="btn-group dropright">
              <i v-if="this.profile.id == this.keepProp.creatorId" class="fa fa-ellipsis-v btn big-button" aria-hidden="true" role="button" data-toggle="dropdown"></i>
              <div class="dropdown-menu ml-1 text-center">
                <p v-if="this.$route.name == 'VaultDetails'" class="btn" @click="deleteVaultKeep">Remove Keep</p>
                <p v-if="this.$route.name == 'Home' && this.profile.id == this.keepProp.creatorId" class="btn" @click="deleteKeep">Delete Keep</p>
              </div>
            </div>
            <!-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button> -->
          </div>
          <div class="modal-body">
            <div class="row">
              <div class="col-8">
                <img :src="keepProp.img" alt="" width="100%">
              </div>
              <div class="col-4 d-flex flex-column">
                <p>Description: {{keepProp.description}}</p>
                <p>Kept: {{keepProp.keeps}}</p>
                <p>Views: {{keepProp.views}}</p>
                <p>Add to my collection:</p>
                <form @submit.prevent="createVaultKeep">
                  <select class="form-control" v-model="newVK.vaultId" required>
                    <option value="" selected disabled>Choose Vault to add to:</option>
                    <option v-for="vault in vaults" :value="vault.id" :key="vault.id" >{{vault.name}}</option>
                  </select>
                  <button class="btn btn-primary">Add to Vault</button>
                </form>
              </div>
            </div>
          </div>
          <div class="modal-footer justify-content-between">
            <div class="d-flex" @click="viewProfile">
              <img :src="keepProp.creator.picture" alt="" width="25%">
              <p class="align-self-end ml-1">{{keepProp.creator.name}}</p> 
            </div>
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
          </div>
        </div>
      </div>
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
      newVK:{
        keepId: 0,
        vaultId: 0
      }
    }
  },
  computed:{
    profile(){
      return this.$store.state.profile;
    },
    vaults(){
      return this.$store.state.vaults;
    }
  },
  methods:{
    deleteKeep(){
     this.$store.dispatch("deleteKeep", this.keepProp.id)
    },
    updateViewCount(){
      let update = this.keepProp
      update.views++;
      this.$store.dispatch("updateKeep", update)
    },
    createVaultKeep(){
      this.newVK.keepId = this.keepProp.id;
      this.$store.dispatch("createVaultKeep", this.newVK);
      this.newVK = {keepId: 0, vaultId: 0};
    },
    deleteVaultKeep(){
      this.$store.dispatch("deleteVaultKeep", this.keepProp.vaultKeepId)
    },
    viewProfile(){
      $("#keepModal").hide();
      $(".modal-backdrop").hide();
      this.$router.push({name:'Profile', params:{profileId: this.keepProp.creatorId}})
    }
  },
  props: ["keepProp"],
  components:{}
}
</script>

<style scoped>
.keep-card{
  position: relative;
}
.card-img{
  width:100%;
}
.avatar{
  width: 15%;
}
.creator-deets{
  position: absolute;
  z-index: 2;
  bottom: 5px;
  left: 5px;
}
.trans-box{
  position:absolute;
  z-index: 1;
  width: 100%;
  height:100%;
}
.trans-box:hover{
  background-color: rgba(7, 7, 7, 0.596);
  cursor: pointer;
}


</style>