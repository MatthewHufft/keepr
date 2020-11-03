<template>
  <div class="profile container-fluid">
    <div class="row">
      <div class="col-12 d-flex flex-column align-items-center text-light">
        <img :src="this.profile.picture" class="rounded-circle" alt="">
        <h2>{{this.profile.name}}</h2>
          <p>Keeps: {{this.keeps.length}}  |  Vaults: {{this.vaults.length}}</p>
      </div>
    </div>
    <div class="row">
      <!-- New Vault Modal -->
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
                    <div class="form-check form-check-inline">
                      <label class="text-dark" for="isPrivateCheckbox">Private Vault</label>
                      <input
                        name="isPrivateCheckbox"
                        class="form-control"
                        type="checkbox"
                        v-model="newVault.isPrivate"
                      />
                    </div>
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
        <!-- New Keep Modal -->
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
                      v-model="payload.newKeep.name"
                      required
                    />
                    <input
                      class="form-control forms-custom"
                      type="text"
                      placeholder="Description ..."
                      v-model="payload.newKeep.description"
                    />
                    <input
                      class="form-control forms-custom"
                      type="text"
                      placeholder="Image URL..."
                      v-model="payload.newKeep.img"
                    />
                    <select class="form-control" v-model="payload.newVK.vaultId" required>
                      <option value="" selected disabled>Choose Vault to add to:</option>
                      <option v-for="vault in vaults" :value="vault.id" :key="vault.id" >{{vault.name}}</option>
                    </select>
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
    <div class="row d-flex justify-content-around mt-4">
        <VaultComponent v-for="vault in vaults" :key="vault.id" :vaultProp="vault"/>
    </div>
    <div class="row ">
      <div class="col-12 text-light text-center"><h1 class="my-4">Keeps</h1></div>
      <div class="card-columns w-75 offset-1">
        <KeepComponent v-for="keep in keeps" :key="keep.id" :keepProp="keep"/>
      </div>
    </div>
  </div>
</template>

<script>
import VaultComponent from "../components/VaultComponent.vue";
import KeepComponent from "../components/KeepComponent.vue";
export default {
name: "Profile",
mounted(){
    this.$store.dispatch("getActiveProfile", this.$route.params.profileId);
    this.$store.dispatch("getProfileVaults", this.$route.params.profileId);
    this.$store.dispatch("getProfileKeeps", this.$route.params.profileId);
  },
  data(){
    return{
      newVault:{
        name: "",
        description: "",
        isPrivate: false
      },
      payload:{
        newKeep:{
        name: "",
        description: "",
        img: ""},
        newVK:{
        keepId: 0,
        vaultId: 0}
      },
    }
  },
  computed:{
    vaults(){
      return this.$store.state.vaults;
    },
    profile(){
      return this.$store.state.activeProfile;
    },
    keeps(){
      return this.$store.state.keeps;
    }

  },
  methods:{
    addVault(){
      this.$store.dispatch("createVault", this.newVault);
      this.newVault = {name: "", description: "", isPrivate: false};
    },
    addKeep(){
      this.$store.dispatch("createKeep", this.payload)
      this.newKeep = {name: "", description: "", img: ""};
      this.newVK = {keepId: 0, vaultId: 0};
    }
  },
  props: [""],
  components:{
    VaultComponent,
    KeepComponent
  }
};
</script>

<style>

</style>
// FIX  Server for some reason has stopped functioning after running Docker. Not sure why yet...