args=("$@")
PBTOKEN="T2qFigHeGOELNkTLw1AS1e0m8Qcu3o1I"
URL=${args[0]}

for (( ; ; )); do
mv new.html old.html 2> /dev/null
curl $URL -L --compressed -s > new.html
DIFF_OUTPUT="$(diff new.html old.html)"
if [ "0" != "${#DIFF_OUTPUT}" ]; then
curl -u $PBTOKEN: https://api.pushbullet.com/v2/pushes -d type=note -d title="Site Changed" -d body="Visit it here $URL"
fi
sleep ${args[1]}
done