<template>
  <div class="card keep-card border-0">
    <img class="card-img " :src="keepProp.img" >
    <div class="creator-deets d-flex text-light flex-column justify-content-end align-items-center overlay" data-toggle="modal" :data-target="'#keepModal'+ keepProp.id" @click="updateViewCount">
      <h2 class="mb-auto hide text-shadow">{{keepProp.name}}</h2>
      <img class="avatar hide mb-2 rounded-circle" :src="keepProp.creator.picture" alt="">
      <p class=" ml-3 hide">{{keepProp.creator.name}}</p>
    </div>
    <div class="modal fade" :id="'keepModal'+ keepProp.id" tabindex="-1" :aria-labelledby="'#keepModal'+ keepProp.id + 'Label'" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="modal-header modal-style text-light">
            <h5 class="modal-title" :id="'#keepModal'+ keepProp.id + 'Label'">{{keepProp.name}}</h5>
            <div class="btn-group dropright">
              <i  class="fa fa-ellipsis-v btn big-button text-light" aria-hidden="true" role="button" data-toggle="dropdown"></i>
              <div class="dropdown-menu ml-1 text-center">
                <p v-if="this.$route.name == 'VaultDetails'" class="btn" @click="deleteVaultKeep">Remove Keep</p>
                <p v-if="this.profile.id == this.keepProp.creatorId" class="btn" @click="deleteKeep">Delete Keep</p>
              </div>
            </div>
          </div>
          <div class="modal-body text-light modal-style">
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
          <div class="modal-footer justify-content-between text-light modal-style">
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
     $("#keepModal").hide();
     $(".modal-backdrop").hide();
     this.$store.dispatch("deleteKeep", this.keepProp.id)
    },
    updateViewCount(){
      let update = this.keepProp
      update.views++;
      this.$store.dispatch("updateKeep", update)
    },
    updateKeptCount(){
      let update = this.keepProp
      update.keeps++;
      this.$store.dispatch("updateKeep", update)
    },
    createVaultKeep(){
      this.newVK.keepId = this.keepProp.id;
      this.$store.dispatch("createVaultKeep", this.newVK);
      this.updateKeptCount();
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
.text-shadow{
  text-shadow: 2px 2px 6px #000000;
}

.card-img{
  vertical-align: top;
  width:100%;
  border-radius: 10px;
  box-shadow: 6px 6px 12px #171818, 
             -5px -5px 12px #333436;

}
.avatar{
  height: 10%;
  width: auto;
}
.creator-deets{
  position: absolute;
  z-index: 2;
  bottom: 5px;
  left: 5px;
}
.hide{
  display:none
}
.keep-card{
  position: relative;
  display: inline-block;
  border-radius: 10px;
  background: #252627;
  box-shadow:   10px 10px 20px #171818, 
             -10px -10px 20px #333436;
}
.overlay{
  transition: 400ms;
}
.keep-card:hover .overlay{
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
.keep-card:hover .hide{
  display:inline-block;
}

.modal-style{
  background-color: rgb(54, 54, 54);
  
}

</style>