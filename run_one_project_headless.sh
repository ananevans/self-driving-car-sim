PATH_PLANNING_HOME=~/work/CarND-Path-Planning-Project/

export CONFIG_FILE=simulator.config
export VIOLATIONS_FILE=violations.txt

pushd $PATH_PLANNING_HOME/build

./path_planning&

popd

sleep 1

./test-headless.x86_64



