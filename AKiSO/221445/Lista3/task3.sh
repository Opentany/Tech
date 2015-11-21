#!/bin/bash
args=("$@")
CURRENTPATH="$(pwd)"
cd ${args[0]}
pwd
echo `find -not -empty -type f -printf "%-30s'\t\"%h/%f\"\n" | sort -rn -t$'\t' | uniq -w30 -D | cut -f 2 -d $'\t' | xargs md5sum | uniq -w32 --all-repeated=separate`
cd $CURRENTPATH