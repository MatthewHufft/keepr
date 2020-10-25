<template>
  <div class="profile container-fluid">
    <div class="row">
      <div class="col-12 d-flex flex-column align-items-center">
        <img :src="this.profile.picture" class="rounded" alt="">
        <h2>Name:{{this.profile.name}}</h2>
      </div>
    </div>
    <div class="row">
      <div class="col-12 d-flex justify-content-end">
        <button
              class="btn btn-danger m-2 bg-danger text-white"
              type="button"
              data-toggle="modal"
              data-target="#newVaultModal"
            >New Vault</button>
        <div
              class="modal fade"
              id="newVaultModal"
              tabindex="-1"
              role="dialog"
              aria-labelledby="newVaultModalLabel"
              aria-hidden="true"
            >
              <div class="modal-dialog shadow-lg" role="document">
                <div class="modal-content text-light">
                  <div class="modal-header bg-danger">
                    <h5 class="modal-title text-light" id="newVaultModalLabel">Create Vault</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <form @submit.prevent="addVault">
                    <input
                      class="form-control forms-custom"
                      type="text"
                      placeholder="Vault Name... "
                      v-model="newVault.name"
                      required
                    />
                    <input
                      class="form-control forms-custom"
                      type="text"
                      placeholder="Description ..."
                      v-model="newVault.description"
                    />
                    <input
                      class="form-control forms-custom"
                      type="checkbox"
                      v-model="newVault.isPrivate"
                    />
                    <div class="modal-footer justify-content-center">
                      <button
                        type="submit"
                        class="btn btn-danger"
                      >Create Vault</button>
                    </div>
                  </form>
                </div>
              </div>
        </div>
        <button
              class="btn btn-danger m-2 bg-danger text-white"
              type="button"
              data-toggle="modal"
              data-target="#newKeepModal"
            >New Keep</button>
        <div
              class="modal fade"
              id="newKeepModal"
              tabindex="-1"
              role="dialog"
              aria-labelledby="newKeepModalLabel"
              aria-hidden="true"
            >
              <div class="modal-dialog shadow-lg" role="document">
                <div class="modal-content text-light">
                  <div class="modal-header bg-danger">
                    <h5 class="modal-title text-light" id="newKeepModalLabel">Create Keep</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <form @submit.prevent="addKeep">
                    <input
                      class="form-control forms-custom"
                      type="text"
                      placeholder="Keep Name... "
                      v-model="newKeep.name"
                      required
                    />
                    <input
                      class="form-control forms-custom"
                      type="text"
                      placeholder="Description ..."
                      v-model="newKeep.description"
                    />
                    <input
                      class="form-control forms-custom"
                      type="text"
                      placeholder="Image URL..."
                      v-model="newKeep.img"
                    />
                    <div class="modal-footer justify-content-center">
                      <button
                        type="submit"
                        class="btn btn-danger"
                      >Create Keep</button>
                    </div>
                  </form>
                </div>
              </div>
        </div>
      </div>
    </div>
    <div class="row">
    <VaultComponent v-for="vault in vaults" :key="vault.id" :vaultProp="vault"/>
    </div>
  </div>
</template>

<script>
import VaultComponent from "../components/VaultComponent.vue";
export default {
name: "Profile",
mounted(){
  },
  data(){
    return{
      newVault:{
        name: "",
        description: "",
        isPrivate: false
      },
      newKeep:{
        name: "",
        description: "",
        img: ""
      },
    }
  },
  computed:{
    vaults(){
      return this.$store.state.vaults;
    },
    profile(){
      return this.$store.state.profile;
    }
  },
  methods:{
    addVault(){
      this.$store.dispatch("createVault", this.newVault);
      this.newVault = {name: "", description: "", isPrivate: false};
    },
    addKeep(){
      this.$store.dispatch("createKeep", this.newKeep);
      this.newKeep = {name: "", description: "", img: ""};
    }
  },
  props: [""],
  components:{
    VaultComponent
  }
};
</script>

<style>

</style>