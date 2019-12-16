<template>
    <div class="label">
        <div class="label__content">
            Echo result: {{ value }}
        </div>
    </div>
</template>
<script>
    export default {
        name: "App",
        data() {
            return {
                value: 25
            };
        },
        async mounted() {
            const result = await fetch("/api/echo?input=Hello,World!");
            this.value = await result.text();
        }
    };
</script>
<style lang="scss">
.label {
    &__content {
        color: magenta;
        font-size: 35px;
        font-weight: bold;
        text-decoration: overline dotted;
    }
}
</style>
