<template>
    <div>
        <div class="label">{{value}}</div>
        <input type="text" v-model="value" />
        <div>{{str}}</div>
    </div>
</template>
<script>
    export default {
        name: "app",
        data() {
            return {
                value: 10,
                str: ""
            };
        },
        watch: {
            value() {
                this.str += "+";
            }
        }
    }
</script>
<style lang="css">
    .label {
        font-size: 20px;
        font-weight: bold;
        text-decoration: double;
    }
</style>