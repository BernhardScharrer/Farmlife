<?php

function connectDB() {
    return new mysqli("localhost", "farmlife", "!Farmlife2019", "farmlife");
}