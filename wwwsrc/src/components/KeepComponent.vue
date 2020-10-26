<template>
  <div class="card col-3">
    <!-- Delete button needs to move into modal -->
    <i class="fa fa-times text-danger" v-if="profile.id == keepProp.creatorId" aria-hidden="true" role="button" @click="deleteKeep"></i>
    <img :src="keepProp.img" role="button" data-toggle="modal" :data-target="'#keepModal'+ keepProp.id" @click="updateViewCount">
    <div class="modal fade" :id="'keepModal'+ keepProp.id" tabindex="-1" :aria-labelledby="'#keepModal'+ keepProp.id + 'Label'" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" :id="'#keepModal'+ keepProp.id + 'Label'">{{keepProp.name}}</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <div class="row">
              <div class="col-8">
                <img :src="keepProp.img" alt="" width="100%">
              </div>
              <div class="col-4">
                <p>Description: {{keepProp.description}}</p>
                <p>Kept: {{keepProp.keeps}}</p>
                <p>Views: {{keepProp.views}}</p>
                <p>Add to my collection:</p>
                <form @submit.prevent="createVaultKeep">
                  <select class="form-control" v-model="newVK.vaultId" required>
                    <option value="" selected disabled>Choose Vault to add to:</option>
                    <option v-for="vault in vaults" :value="vault.id" :key="vault.id" >{{vault.name}}</option>
                  </select>
                </form>
              </div>
            </div>
          </div>
          <div class="modal-footer justify-content-between">
            <div class="d-flex">
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
    }
  },
  props: ["keepProp"],
  components:{}
}
</script>

<style scoped>
img{
  
}

</style>